addCustomMenuItems: aCustomMenu hand: aHandMorph

	"super addCustomMenuItems: aCustomMenu hand: aHandMorph."
	aCustomMenu addLine.
	aCustomMenu add: 'update from original' action: #updateFromOriginal.
	aCustomMenu addList: #(('border color...' changeBorderColor:)
						('border width...' changeBorderWidth:)).
	aCustomMenu addLine.
