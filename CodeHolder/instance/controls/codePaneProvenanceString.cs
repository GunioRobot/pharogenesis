codePaneProvenanceString
	"Answer a string that reports on code-pane-provenance"

	| symsAndWordings |
	(symsAndWordings _ self contentsSymbolQuints) do:
		[:aQuad |
			contentsSymbol == aQuad first ifTrue: [^ aQuad fourth]].
	^ symsAndWordings first fourth "default to plain source, for example if nil as initially"