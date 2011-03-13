step

	| delta |

	owner == self world ifFalse: [^ self].
	owner addMorphInLayer: self.
	delta _ self bounds amountToTranslateWithin: self worldBounds.
	delta = (0 @ 0) ifFalse: [self position: self position + delta].
