chooseMagnification
	| result |
	result _ (SelectionMenu selections: #(1.5 2 4 8))
		startUpWithCaption: ('Choose magnification
(currently {1})' translated format:{magnification}).
	(result isNil or: [result = magnification]) ifTrue: [^ self].
	magnification _ result.
	self extent: self extent. "round to new magnification"
	self changed. "redraw even if extent wasn't changed"