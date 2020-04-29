package com.practise.DynamicProgramming;

public class KnapsackProblem {

public static void main(String args[]) {
    KnapsackProblem knapsack = new KnapsackProblem();
    int[] weights = new int[] { 1, 3, 4, 5 };
    int[] values = new int[] { 1, 4, 5, 7 };
    int totalWeight = 7;
    int maxValue = knapsack.getMaximumValueForAllowedWeight(weights, values, totalWeight);
}

public int getMaximumValueForAllowedWeight(int[] weights, int[] values, int totalWeight) {

    int[][] valuesForWeights = new int[weights.length + 1][totalWeight + 1];

    for(int i = 0 ; i <= totalWeight; i++) {
        valuesForWeights[0][i] = 0;
    }

    for(int i = 0 ; i <= weights.length; i++) {
        valuesForWeights[i][0] = 0;
    }

    for(int i = 1; i <= weights.length; i++) {

        for(int j = 1; j <= totalWeight; j++) {

            if(weights[i-1]  > j ) {
                valuesForWeights[i][j] = valuesForWeights[i-1][j];
            } 

            else {
                valuesForWeights[i][j] = Math.max(valuesForWeights[i-1][j], values[i-1] + valuesForWeights[i-1][j - weights[i-1]]);
            }
        }
    }

    System.out.println("Values for weights");

    for(int i = 0; i <= weights.length; i++) {
        for(int j = 0; j <= totalWeight; j++) {
            System.out.print(valuesForWeights[i][j] + "\t");
        }
        System.out.println();
    }

    int l = weights.length;
    int m = totalWeight;
    System.out.println("Included Weights");
    
    while( valuesForWeights[l][m] != 0) {
        if(valuesForWeights[l-1][m] == valuesForWeights[l][m]) {
            l = l-1;
        }
        else {
            System.out.println(weights[l-1]);
            m = m - weights[l-1]; 
        }
    }

    return valuesForWeights[weights.length][totalWeight];
}
}