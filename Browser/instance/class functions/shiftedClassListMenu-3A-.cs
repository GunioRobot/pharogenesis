shiftedClassListMenu: aMenu
	"Set up the menu to apply to the receiver's class list when the shift key is down"

	^ aMenu addList: #(
			-
			('unsent methods'			browseUnusedMethods	'browse all methods defined by this class that have no senders')
			('unreferenced inst vars'	showUnreferencedInstVars	'show a list of all instance variables that are not referenced in methods')
			('unreferenced class vars'	showUnreferencedClassVars	'show a list of all class variables that are not referenced in methods')
			('subclass template'			makeNewSubclass		'put a template into the code pane for defining of a subclass of this class')
			-
			('sample instance'			makeSampleInstance		'give me a sample instance of this class, if possible')
			('inspect instances'			inspectInstances			'open an inspector on all the extant instances of this class')
			('inspect subinstances'		inspectSubInstances		'open an inspector on all the extant instances of this class and of all of its subclasses')
			-
			('fetch documentation'		fetchClassDocPane		'once, and maybe again someday, fetch up-to-date documentation for this class from the Squeak documentation repository')
			('add all meths to current chgs'		addAllMethodsToCurrentChangeSet
																'place all the methods defined by this class into the current change set')
			('create inst var accessors'	createInstVarAccessors	'compile instance-variable access methods for any instance variables that do not yet have them')
			-
			('more...'					offerUnshiftedClassListMenu	'return to the standard class-list menu'))