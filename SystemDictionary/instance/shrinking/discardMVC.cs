discardMVC
   "Smalltalk discardMVC"

	| keepers |
	Smalltalk isMorphic ifFalse:
		[PopUpMenu notify: 'You must be in a Morphic project to discard MVC.'.
		^ self].
	"Check that there are no MVC Projects"
	(Project allInstances inject: true into: [:ok :proj | ok & proj isMorphic]) ifFalse:
		[(self confirm: 'Would you like a chance to remove your
MVC projects in an orderly manner?')
					ifTrue: [^ self].
		(self confirm: 'If you wish, I can remove all MVC projects,
make this project be the top project, and place
all orphaned sub-projects of MVC parents here.
Would you like be to do this
and proceed to discard all MVC classes?')
					ifTrue: [self zapMVCprojects]
					ifFalse: [^ self]].
	Smalltalk reclaimDependents.

	"Remove old Paragraph classes and View classes."
	(ChangeSet superclassOrder: Paragraph withAllSubclasses asArray) reverseDo: 
		[:c | c removeFromSystem].
	(ChangeSet superclassOrder: View withAllSubclasses asArray) reverseDo: 
		[:c | c removeFromSystem].

	"Get rid of ParagraphEditor's ScrollController dependence"
	#(markerDelta viewDelta scrollAmount scrollBar computeMarkerRegion) do:
			[:sel | ParagraphEditor removeSelector: sel].
	ParagraphEditor compile: 'updateMarker'.
	ParagraphEditor superclass: MouseMenuController .

	"Get rid of all Controller classes not needed by ParagraphEditor and ScreenController"
	keepers _ TextMorphEditor withAllSuperclasses copyWith: ScreenController.
	(ChangeSet superclassOrder: Controller withAllSubclasses asArray) reverseDo: 
		[:c | (keepers includes: c) ifFalse: [c removeFromSystem]].

	SystemOrganization removeCategoriesMatching: 'ST80-Paths'.
	SystemOrganization removeCategoriesMatching: 'ST80-Pluggable Views'.

	Smalltalk removeClassNamed: 'FormButtonCache'.
	Smalltalk removeClassNamed: 'WindowingTransformation'.
	Smalltalk removeClassNamed: 'ControlManager'.
	Smalltalk removeClassNamed: 'DisplayTextView'.

	ScheduledControllers _ nil.
	Undeclared removeUnreferencedKeys.
	SystemOrganization removeEmptyCategories.
	Symbol rehash.
