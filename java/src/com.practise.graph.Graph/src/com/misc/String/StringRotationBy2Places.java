package com.misc.String;

/// geeksforgeeks.org/check-string-can-obtained-rotating-another-string-2-places/

public class StringRotationBy2Places {

    public static void main(String args[]) {
        StringRotationBy2Places sr = new StringRotationBy2Places();
        String s1 = "amazon";
        String s2 = "azonam";
        System.out.println(compareString(s1, s2));
    }

    public static boolean compareString(String s1, String s2) {
        // rotation can be clockwise or anit clockwise
        // naive approach
        // first 2 letters shift anticlockwise to append to end or
        // add last 2 letters from end to front
        String s3 =s1 + s2;
        if(s3.contains(s1)) {
            return true;
        }
        
        int l1 = s1.length();
        int l2 = s2.length();
        boolean isRotated = false;
        int start = 2;
        int i = 2;
        int j = 0;
        while(true) {
            if(s1.charAt(i) == s2.charAt(j)) {
                i++; j++;
            } else {
                return false;
            }
            if(i >= l1) {
                i = i % l1;
                isRotated = true;
            }
            if(isRotated && i == start) {
                return true;
            } 
        }
    }
}