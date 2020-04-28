package com.practise.DynamicProgramming;

import java.util.List;
import java.util.ArrayList;

public class LongestCommonSubsequence {

    public static void main(String args[]) {

        LongestCommonSubsequence lcs = new LongestCommonSubsequence();
        String s1 = "ABCDGH";
        String s2 = "AEDFHR";
        StringBuffer sb = new StringBuffer();
        System.out.println(lcs.findLCS(s1, 0, s2, 0, 0, sb));
        System.out.print(sb.toString());

    }

    public int findLCS(String s1, int i, String s2, int j, int max_so_far, StringBuffer sb) {

        if( s1 == null || s2 == null ) {
            return 0;
        }

        if(i >= s1.length() || j >= s2.length()) {
            return 0;
        }
        
        int max_result = 0;

        int left = findLCS(s1, i+1, s2, j, max_so_far, sb);
        int right = findLCS(s1, i, s2, j+1, max_so_far, sb);

        max_result = Math.max(left, right);

        if(max_so_far < max_result) {
            max_so_far = max_result;
        }

        if( s1.charAt(i) == s2.charAt(j) ) {
            sb.append(s1.charAt(i));
            System.out.print(s1.charAt(i));
            max_so_far = 1 + max_so_far;
        }
        return max_so_far;
    }
}