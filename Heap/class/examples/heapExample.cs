heapExample	"Heap heapExample"
	"Create a sorted collection of numbers, remove the elements
	sequentially and add new objects randomly.
	Note: This is the kind of benchmark a heap is designed for."
	| n rnd array time sorted |
	n _ 5000. "# of elements to sort"
	rnd _ Random new.
	array _ (1 to: n) collect:[:i| rnd next].
	"First, the heap version"
	time _ Time millisecondsToRun:[
		sorted _ Heap withAll: array.
		1 to: n do:[:i| 
			sorted removeFirst.
			sorted add: rnd next].
	].
	Transcript cr; show:'Time for Heap: ', time printString,' msecs'.
	"The quicksort version"
	time _ Time millisecondsToRun:[
		sorted _ SortedCollection withAll: array.
		1 to: n do:[:i| 
			sorted removeFirst.
			sorted add: rnd next].
	].
	Transcript cr; show:'Time for SortedCollection: ', time printString,' msecs'.
