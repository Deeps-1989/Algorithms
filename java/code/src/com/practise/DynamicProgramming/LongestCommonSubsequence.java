package com.practise.DynamicProgramming;

public class LongestCommonSubsequence {

    public static void main(String args[]) {
        LongestCommonSubsequence lcs = new LongestCommonSubsequence();
        String s1 = "acbcf";
        String s2 = "abcdaf";
        lcs.bottomUpLcs(s1, s2);
    }

    public int bottomUpLcs(String s1, String s2) {
        int n1 = s1.length();
        int n2 = s2.length(); 
        int[][] lcs = new int[ n1 + 1 ][ n2 + 1 ];
        for(int i = 0; i <= n1; i++) {
            for(int j = 0; j <= n2; j++) {

                if(i == 0 || j == 0) {
                    lcs[i][j] = 0;
                    continue;
                }

                if(s1.charAt(i-1) == s2.charAt(j-1)) {
                    lcs[i][j] = lcs[i-1][j-1] + 1;
                }
                else {
                    lcs[i][j] = Math.max(lcs[i-1][j], lcs[i][j-1]);
                }
            }
        }
        System.out.println(String.format("Printing the data n1 %s, n2 %s", n1, n2));
        for(int i = 0; i <= n1; i++) {
            for(int j = 0; j <= n2; j++) {
                System.out.print(lcs[i][j] + "\t");
            }
            System.out.println();
        }

        // print all characters involved in lcs
        int l = n1;
        int m = n2;
        while(lcs[l][m] != 0) {
            if(lcs[l][m] == lcs[l-1][m-1] + 1 && s1.charAt(l-1) == s2.charAt(m-1)) {
                System.out.print(s2.charAt(m-1));
                l = l-1;
                m = m-1;
            } 
            else {
                if(lcs[l-1][m] > lcs[l][m-1]) {
                    l = l-1;
                } else{
                    m = m-1;
                }
            }
        }

        return lcs[n1][n2];
    }
}