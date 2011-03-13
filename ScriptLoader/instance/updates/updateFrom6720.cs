updateFrom6720
	"self new updateFrom6720"
	"
	- Tools for traits fixes from adrian
	- underscore fixing
	- integer printing fixes + tests
	- 0002708: SharedQueue does not nil out unused slots when flushing
	- 0002154: Light-weight mutex implementation
	- tests from 0002688: aNumber = (aNumber + 0 i) answer false
	- Adds a test for the new Url class>>absoluteFromFileNameOrUrlString: 
	- Set new now uses new: 5
	- delete Undefined>>languagePrefs, broken code
	- tests for primesUpTo: and isPrime
	- turn on Deprecation warnings
	- Move Heap examples to HeapTest (and call them in a test)
	- remove double entry for TestRunner from open Menu
	- clean a bit old unneded tests
	- remove empty class and method categories
	- fix a call to deprecated #bringFlapTabsToFront
	- Change Set:		fixPntrFinder-bf
	  Author:			Bert Freudenberg
	  The PointerFinder (aka 'chase pointers' menu item) did not find references in   
	  CompiledMethods, which are the only objects in the system that answer false to isPointers  
	  but still *do* have pointers"
	
	self script32.
	self flushCaches.
	
	Preferences setPreference: #showDeprecationWarnings toValue: true.
	TheWorldMenu unregisterOpenCommand: 'SUnit Test Runner'.
	Smalltalk removeEmptyMessageCategories.
	SystemOrganization removeEmptyCategories.
	
	Undeclared removeUnreferencedKeys.
	Smalltalk garbageCollect.
	ScheduledControllers := nil.
	Smalltalk garbageCollect.
	
	SMSqueakMap default purge.
	Smalltalk forgetDoIts.

	DataStream initialize.
	Behavior flushObsoleteSubclasses.
	MethodChangeRecord allInstancesDo: [:each | each noteNewMethod: nil].
	
	SmalltalkImage current fixObsoleteReferences.

	Smalltalk flushClassNameCache.
	3 timesRepeat: [
		Smalltalk garbageCollect.
		Symbol compactSymbolTable.
	].
