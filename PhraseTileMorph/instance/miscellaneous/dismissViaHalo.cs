dismissViaHalo
	"The user has clicked in the delete halo-handle.."

	| ed |
	ed _ self topEditor.
	super dismissViaHalo.
	ed ifNotNil: [ed scriptEdited]