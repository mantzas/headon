package main

import (
	"flag"
	"fmt"
	"time"
)

func main() {
	taskCount := flag.Int("tasks", 1, "count of strings to process")
	flag.Parse()

	if *taskCount == 0 {
		flag.Usage()
		return
	}

	fmt.Printf("Task to execute: %d", *taskCount)
	fmt.Println()

	start := time.Now()

	for i := 0; i < *taskCount; i++ {

		_ = fmt.Sprintf("Task %d done!", i)
	}

	elapsed := time.Since(start)
	fmt.Printf("%d in %s", *taskCount, elapsed)
	fmt.Println()
}
