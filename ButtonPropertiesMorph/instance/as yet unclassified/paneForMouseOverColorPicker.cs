paneForMouseOverColorPicker

	^self 
		inAColumn: {
			(self inAColumn: {
				self colorPickerFor: self targetProperties
						 getter: #mouseOverHaloColor setter: #mouseOverHaloColor:.
				self lockedString: 'mouse-over halo color' translated.
				self paneForMouseOverHaloWidth.
			}
			named: #pickerForMouseOverColor) layoutInset: 0.
		}
