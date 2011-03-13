colorMapForDepth: d

	| fore back |
	fore _ foregroundColor bitPatternForDepth: d.
	back _ backgroundColor bitPatternForDepth: d.
	^ Bitmap with: back first with: fore first.
