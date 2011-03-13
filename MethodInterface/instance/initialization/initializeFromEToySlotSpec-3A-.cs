initializeFromEToySlotSpec: tuple
	"tuple holds an old etoyslot-item spec, of the form found in #additionsToViewerCategories methodds.   Initialize the receiver to hold the same information"

	| setter |
	selector _ tuple seventh.
	self documentation: tuple third.
	resultSpecification _ ResultSpecification new.
	resultSpecification resultType: tuple fourth.

	((tuple fifth == #readWrite) and: [((tuple size >= 9) and: [(setter _ tuple at: 9) ~~ #unused])]) ifTrue:
		[resultSpecification companionSetterSelector: setter].
		

"slot amount 'The amount of displacement' number readOnly player getAmount unused unused"
	