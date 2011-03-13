updateFrom6717
	"self new updateFrom6717"
	"Some Changes form the ClosureCompiler
	 ----
	Name: SUnitGUI-lr.4
	- changed the label from 'Essential Test Runner' to 'Test Runner', since there is no other 	anymore this makes no sense to distinguish
	- renamed the button 'Run All' to 'Run Selected' to avoid confusion
	-----
	Change Set:		fileinUndeclared-bf
	Date:			12 January 2006
	Author:			Bert Freudenberg
	When filing in, do not ask whether it's okay to moveclass var to Undeclared. Just move it.
	-----
	Change Set:		DebuggerMVCSchedulingFix-dtl
	Date:			12 December 2005
	Author:			David T. Lewis
	Mantis bug 0002359: Debugger in MVC opens in next available Morphic world
	-----
	Name: CollectionsTests-zz.11
	Author: zz
	Add more tests to several Collection classes : Array, Association, Dictionary, Heap, Interval, 	LinkedList, OrderedCollection, SequenceableCollection, SortedCollection
	All tests are green ;-)
	-----
	added haltOnce (with halt on count, inspect at count, and inspect until count)
	-----
	removed emptyCheck from OrderedCollection removeLast, removeFirst
	"
	
	self script28.
	self flushCaches.