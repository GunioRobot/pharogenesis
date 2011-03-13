showList
	"Show the list."

	self listMorph owner isNil
		ifTrue: [self listMorph
					bounds: (self boundsInWorld bottomLeft extent: self width @ self listHeight).
				self listPaneColor: self paneColor.
				self world addMorphInLayer: self listMorph.
				self buttonMorph roundedCorners: (self roundedCorners copyWithoutAll: #(1 2 3)).
				self roundedCorners: (self roundedCorners copyWithoutAll: #(2 3)).
				self changed.
				self listMorph wantsKeyboardFocus ifTrue: [
					self listMorph takeKeyboardFocus].
				self activeHand
					newMouseFocus: self listMorph]