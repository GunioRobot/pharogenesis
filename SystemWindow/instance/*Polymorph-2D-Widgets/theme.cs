theme
	"Answer the ui theme that provides controls.
	Don't call super since that implementation may delegate here."

	(self valueOfProperty: #theme) ifNotNilDo: [:t | ^ t].
	^self class theme