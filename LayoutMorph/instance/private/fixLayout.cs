fixLayout

	| extraPerMorph nextPlace space |
	orientation == #free ifTrue: [^ self].
	extraPerMorph _ self extraSpacePerMorph.
	orientation = #horizontal
		ifTrue: [nextPlace _ bounds left + inset + borderWidth]
		ifFalse: [nextPlace _ bounds top + inset + borderWidth].
	submorphs do: [:m |
		space _ self placeAndSize: m at: nextPlace padding: extraPerMorph.
		nextPlace _ nextPlace + space].
