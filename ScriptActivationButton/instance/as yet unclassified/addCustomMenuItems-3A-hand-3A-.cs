addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Add morph-specific items to the given menu which was invoked by the given hand.  To avoid a nasty inheritance problem, this method does NOT call super"

	aCustomMenu addUpdating: #hasDragAndDropEnabledString action: #changeDragAndDrop.

	aCustomMenu add: 'put in a window' action: #embedInWindow.
	aCustomMenu addUpdating: #stickinessString target: self action: #toggleStickiness.
	aCustomMenu add: 'adhere to edge...' action: #adhereToEdge.

	aCustomMenu addList: 
			#(('border color...' changeBorderColor:)
			('border width...' changeBorderWidth:)).
	aCustomMenu addUpdating: #roundedCornersString target: self action: #toggleCornerRounding.

	borderColor == #raised ifFalse: [aCustomMenu add: 'raised bevel' action: #borderRaised].
	borderColor == #inset ifFalse: [aCustomMenu add: 'inset bevel' action: #borderInset].
	self addLabelItemsTo: aCustomMenu hand: aHandMorph.
	aCustomMenu add: 'open underlying scriptor' target: target selector: #openUnderlyingScriptorFor: argument: arguments first

