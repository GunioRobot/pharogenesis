asWindow: aRectangle
	^(aRectangle origin * topSize extent) truncated
		corner: (aRectangle corner * topSize extent) truncated