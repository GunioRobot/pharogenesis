mostGenericButton
	"Answer a button that reports on, and allow the user to modify, the most generic class to show"

	| aButton |
	aButton _ UpdatingSimpleButtonMorph newWithLabel: 'All'.
	aButton setNameTo: 'limit class'.
	aButton target: self; wordingSelector: #limitClassString; actionSelector: #chooseLimitClass.
	aButton setBalloonText: 
'Governs which classes'' methods should be shown.  If this is the same as the viewed class, then only methods implemented in that class will be shown.  If it is ProtoObject, then methods of all classes in the vocabulary will be shown.'.
	aButton actWhen: #buttonDown.
	aButton color: Color transparent.
	aButton borderColor: Color black.
	^ aButton