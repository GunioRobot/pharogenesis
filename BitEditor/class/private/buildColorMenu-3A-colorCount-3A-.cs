buildColorMenu: extent colorCount: nColors
	"See BitEditor magnifyWithSmall."

	| menuView index form aSwitchView connector
	button formExtent highlightForm color leftOffset |
	connector _ Object new.
	menuView _ FormMenuView new.
	menuView window: (0@0 corner: extent).
	formExtent _ 30@30 min: extent//(nColors*2+1@2).  "compute this better"
	leftOffset _ extent x-(nColors*2-1*formExtent x)//2.
	highlightForm _ Form extent: formExtent.
	highlightForm borderWidth: 4.
	1 to: nColors do:
		[:index | 
		color _ (nColors=1
			ifTrue: [#(black)]
			ifFalse: [#(black gray)]) at: index.
		form _ Form extent: formExtent.
		form fill: form boundingBox fillColor: (Color perform: color).
		form borderWidth: 5.
		form border: form boundingBox width: 4 fillColor: form white.
		button _ Button new.
		index = 1 ifTrue:
			[button onAction: [menuView model setColor: Color fromUser]]
			ifFalse:
			[button onAction: [menuView model setTransparentColor]].

		aSwitchView _ SwitchView new model: button.
		aSwitchView key: ((nColors=3 ifTrue: ['xvn'] ifFalse: ['xn']) at: index).
		aSwitchView label: form.
		aSwitchView window: (0@0 extent: form extent).
		aSwitchView translateBy: (index-1*2*form width+leftOffset) @ (form height//2).
		aSwitchView highlightForm: highlightForm.
	
		aSwitchView borderWidth: 1.
		aSwitchView controller selector: #turnOn.
		menuView addSubView: aSwitchView].
	^menuView