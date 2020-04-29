package com.practise.backtracking;

import java.util.List;
import java.util.ArrayList;

public class SubsetSumProblem {

    public static void main(String args[]) {
        int sum = 11;
        int[] arr = { 1, 2, 3, 4, 5, 6 };
        SubsetSum ss = new SubsetSum();
        ss.findSubsetSum(arr, sum, arr.length, 0);
        ss.printSumList();
    }
}

class SubsetSum {
    private List<Integer> sumList = new ArrayList<>();
    
    public boolean findSubsetSum(int[] arr, int sum, int n, int k) {

     if(sum  == 0) {
        printSumList();
        findSubsetSum(arr, sum + arr[k-1], n, k);
     }
     for(int i = k; i < n; i++) {
         sumList.add(arr[i]);
         if(findSubsetSum(arr, sum - arr[i], n, i + 1)) {
             return true;
         }
         sumList.remove(sumList.indexOf(arr[i]));
     }
     return false;
    }

    public void printSumList() {
        for(int i = 0; i < sumList.size(); i++) {
            System.out.print(sumList.get(i) + " ");
        }
        System.out.println();
    }
}