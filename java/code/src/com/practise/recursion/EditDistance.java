package com.practise.recursion;

public class EditDistance {
    public static void main(String args[]) {
        EditDistance ed = new EditDistance();
        String s1 = "deepak";
        String s2 = "deeps";
        int min_result = Integer.MAX_VALUE;
        System.out.println(ed.getOperations(s1, s2, s1.length() - 1 , s2.length() - 1, min_result));
    }

    public int getOperations(String s1, String s2, int m, int n, int min_result) {
 
        if( (m == 0 && n == 0 && s1.charAt(m) == s2.charAt(n)) || m < 0 || n < 0) {
            return 0;
        }
        if( m == 0 && n == 0 ) {
            return 1;
        }
        if(s1.charAt(m) == s2.charAt(n)) {
            return getOperations(s1, s2, m-1, n-1, min_result);
        }
        int remove = 1 + getOperations(s1, s2, m-1, n, min_result);
        int update = 1 + getOperations(s1, s2, m-1, n-1, min_result);
        int insert = 1 + getOperations(s1, s2, m, n-1, min_result);

        int result = Math.min(remove, Math.min(update, insert));
        if( result < min_result ) {
            min_result = result;
        }
        return min_result;
    }
}