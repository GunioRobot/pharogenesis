fixLayoutStagger
	| nextPlace |

	orientation = #horizontal
		ifTrue: [nextPlace _ bounds left + inset + borderWidth]
		ifFalse: [nextPlace _ bounds top + inset + borderWidth].

	submorphs reverseDo: [:m |
		self placeAndSize: m at: nextPlace padding: 0.
		nextPlace _ nextPlace + self staggerOffset].
