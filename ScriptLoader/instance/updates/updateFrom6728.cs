updateFrom6728
	"self new updateFrom6728"
	
	"
	- fixed override of Services to not revert Traits browser change
	- 0002868: Copying the text of a list morph via the halo menu does return empty
	- 
	
	Change Set:		TestRunnerEnh
	Date:			18 February 2006
	Author:			Alexandre Bergel

	With this fix, the TestRunner now update its list of classes and categories accordingly to 	system changes. It uses the SystemChangeNotifier.
	
	Name: CollectionsTests-fbs.16
	Author: fbs
	Time: 14 February 2006, 5:44:42 pm
	UUID: bfeee468-b072-1048-9409-ed02f938ff47
	Ancestors: CollectionsTests-md.14

	This version converts == <integer literal> to = <integer literal> in response to Dan Ingalls' 	note: http://lists.squeakfoundation.org/pipermail/squeak-dev/2006-February/100600.html


	Traits: Change log:
	- fixed marker methods that were broken because of new default literals in CompiledMethod
	- removed obsolete requries algorithm tests
	- prefixed all requires performance tests to exclude them from normal test runs
	- fixed issue [0002814] (targetTraits is shadowed in RequiredSelectorsChangesCalculator)
	- requires algorithm bugfix (requirements are not dynamically updated for classes) by 	Daniel
	- all traits and requires tests should run green again except for 	TraitCompositionTest>>testProvidedMethodBindingsWithConflicts

	Fast #who changes / cleanups
	- deprecate CompiledMethod>>#decompileClass:selector:
	- delete Compiler>>#cacheDoItNode
	- remove ivar cacheDoItNode
     - remove CompiledMethod>>#blockNode, blockNodeIn,   
	- remove Message>>catcher
	- remove MethodContext>>methodNode (use inherited version from MethodContext)


	Name: SmaCC-fbs.8
	Author: fbs
	Time: 14 February 2006, 6:00:22 pm
	UUID: baaa0a47-646f-8345-bede-968f4cdaaff2
	Ancestors: SmaCC-stephaneducasse.6

	This version converts == <integer literal> to = <integer literal> in response to Dan Ingalls' 	note: http://lists.squeakfoundation.org/pipermail/squeak-dev/2006-February/100600.html
"
	self script37.
	self flushCaches.
	
	RequiredSelectors initialize.
	LocalSends initialize.
	ProvidedSelectors initialize.
	Compiler recompileAll.
