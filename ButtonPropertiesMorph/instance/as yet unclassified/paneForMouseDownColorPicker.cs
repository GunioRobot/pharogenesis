paneForMouseDownColorPicker

	^self 
		inAColumn: {
			(self inAColumn: {
				self colorPickerFor: self targetProperties
						 getter: #mouseDownHaloColor setter: #mouseDownHaloColor:.
				self lockedString: 'mouse-down halo color' translated.
				self paneForMouseDownHaloWidth.
			}
			named: #pickerForMouseDownColor) layoutInset: 0.
		}
