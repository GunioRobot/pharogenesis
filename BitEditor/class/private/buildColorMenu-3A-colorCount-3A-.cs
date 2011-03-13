buildColorMenu: extent colorCount: nColors
	"See BitEditor magnifyWithSmall."

	| menuView form aSwitchView
	 button formExtent highlightForm color leftOffset |
	menuView _ FormMenuView new.
	menuView window: (0@0 corner: extent).
	formExtent _ 30@30 min: extent//(nColors*2+1@2).  "compute this better"
	leftOffset _ extent x-(nColors*2-1*formExtent x)//2.
	highlightForm _ Form extent: formExtent.
	highlightForm borderWidth: 4.
	1 to: nColors do: [:index | 
		color _ (nColors = 1
			ifTrue: [#(black)]
			ifFalse: [#(black gray)]) at: index.
		form _ Form extent: formExtent.
		form fill: form boundingBox fillColor: (Color perform: color).
		form borderWidth: 5.
		form border: form boundingBox width: 4 fillColor: Color white.
		button _ Button new.
		index = 1
			ifTrue: [button onAction: [menuView model setColor: Color fromUser]]
			ifFalse: [button onAction: [menuView model setTransparentColor]].

		aSwitchView _ PluggableButtonView
			on: button
			getState: #isOn
			action: #turnOn.
		aSwitchView
			shortcutCharacter: ((nColors=3 ifTrue: ['xvn'] ifFalse: ['xn']) at: index);
			label: form;
			window: (0@0 extent: form extent);
			translateBy: (((index - 1) * 2 * form width) + leftOffset)@(form height // 2);
			borderWidth: 1.
		menuView addSubView: aSwitchView].
	^ menuView
