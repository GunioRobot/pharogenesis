discardMVC
	"After suitable checks, strip out much of MVC from the system"
	"Smalltalk discardMVC"
	| keepers |
	self flag: #bob.
	"zapping projects"
	self isMorphic
		ifFalse: [self inform: 'You must be in a Morphic project to discard MVC.'.
			^ self].
	"Check that there are no MVC Projects"
	(Project allProjects
			allSatisfy: [:proj | proj isMorphic])
		ifFalse: [(self confirm: 'Would you like a chance to remove your
MVC projects in an orderly manner?')
				ifTrue: [^ self].
			(self confirm: 'If you wish, I can remove all MVC projects,
make this project be the top project, and place
all orphaned sub-projects of MVC parents here.
Would you like be to do this
and proceed to discard all MVC classes?')
				ifTrue: [self zapMVCprojects]
				ifFalse: [^ self]].
	self reclaimDependents.
	"Remove old Paragraph classes and View classes."
	self
		at: #Paragraph
		ifPresent: [:paraClass | (ChangeSet superclassOrder: paraClass withAllSubclasses asArray)
				reverseDo: [:c | c removeFromSystem]].
	self
		at: #View
		ifPresent: [:viewClass | (ChangeSet superclassOrder: viewClass withAllSubclasses asArray)
				reverseDo: [:c | c removeFromSystem]].
	"Get rid of ParagraphEditor's ScrollController dependence"
	#(#markerDelta #viewDelta #scrollAmount #scrollBar #computeMarkerRegion )
		do: [:sel | ParagraphEditor removeSelector: sel].
	ParagraphEditor compile: 'updateMarker'.
	"Reshape to MouseMenuController"
	Compiler
		evaluate: (ParagraphEditor definition copyReplaceAll: 'ScrollController' with: 'MouseMenuController').
	"Get rid of all Controller classes not needed by
	ParagraphEditor and ScreenController"
	keepers := TextMorphEditor withAllSuperclasses copyWith: ScreenController.
	(ChangeSet superclassOrder: Controller withAllSubclasses asArray)
		reverseDo: [:c | (keepers includes: c)
				ifFalse: [c removeFromSystem]].
	SystemOrganization removeCategoriesMatching: 'ST80-Paths'.
	SystemOrganization removeCategoriesMatching: 'ST80-Symbols'.
	SystemOrganization removeCategoriesMatching: 'ST80-Pluggable Views'.
	self removeClassNamed: 'FormButtonCache'.
	self removeClassNamed: 'WindowingTransformation'.
	self removeClassNamed: 'ControlManager'.
	self removeClassNamed: 'DisplayTextView'.
	ScheduledControllers := nil.
	Undeclared removeUnreferencedKeys.
	SystemOrganization removeEmptyCategories.
	Symbol rehash