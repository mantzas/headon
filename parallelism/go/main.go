package main

import (
	"flag"
	"fmt"
	"sync"
	"time"
)

func main() {
	taskCount := flag.Int("tasks", 1, "count of task to parallelize")
	flag.Parse()

	if *taskCount == 0 {
		flag.Usage()
		return
	}

    fmt.Printf("Task to execute: %d", *taskCount)
    fmt.Println()

    var wg sync.WaitGroup
    wg.Add(*taskCount)
	
    start := time.Now()

	for i := 0; i < *taskCount; i++ {
        
        go func(i int) {
            _ = fmt.Sprintf("Task %d done!", i)
            wg.Done()
        }(i)
	}
    
    wg.Wait()
    elapsed := time.Since(start);
    fmt.Printf("%d in %s", *taskCount, elapsed)
}
