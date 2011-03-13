scaledToSize: newExtent

	| scale |

	newExtent = self extent ifTrue: [^self].
	scale _ newExtent x / self width min: newExtent y / self height.
	^self magnify: self boundingBox by: scale smoothing: 2.
