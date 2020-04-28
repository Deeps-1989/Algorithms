package com.practise.recursion;

import java.util.List;
import java.util.ArrayList;

/// Find the maximum length path (starting from any cell) 
/// such that all cells along the path are in increasing order with a difference of 1.
/// All numbers in metrix are distinct
/// We can move in 4 directions from a given cell (i, j), 
/// i.e., we can move to (i+1, j) or (i, j+1) or (i-1, j) or (i, j-1)
public class LongestPathInMatrix {

    static int[] row = { 0, 1, -1, 0 };
    static int[] col = { 1, 0, 0, -1 };

    public static void main(final String args[]) {
        final int n = 3;
        final LongestPathInMatrix lpm = new LongestPathInMatrix();
        final int[][] mat = {
                {1,2,9},
                {5,3,8},
                {4,6,7}
        };

        final List<Integer> max_list_so_far = new ArrayList<>();
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                lpm.findLongestPath(mat, i, j, max_list_so_far);
            }
        }
        for (final int m: max_list_so_far) {
            System.out.print(m + " ");
        }
        System.out.println();
    }

    public void findLongestPath(final int[][] mat, final int i, final int j, final List<Integer> max_list_so_far) {

        final List<Integer> max_list = new ArrayList<>();
        findLongestPathUtil(mat, i, j, max_list);
        if(max_list.size() > max_list_so_far.size()) {
            max_list_so_far.clear();
            max_list_so_far.addAll(max_list);
        }
    }

    public boolean findLongestPathUtil(final int[][] mat, final int i, final int j, final List<Integer> max_list) {
        max_list.add(mat[i][j]);
        for(int k = 0; k < row.length; k++) {
                if (isSafeToAdd(mat, i, j, i + row[k], j+ col[k])) {
                    if(findLongestPathUtil(mat,i + row[k], j + col[k], max_list)) {
                        return true;
                    } 
                }
        }
        return false;
    }

    public boolean isSafeToAdd(final int[][] mat, final int i, final int j, final int a, final int b) {
        final int n = mat.length;
        if(a >= 0 && a < n && b >=0 && b < n && mat[i][j] + 1  == mat[a][b]) {
            return true;
        }
        return false;
    }
}