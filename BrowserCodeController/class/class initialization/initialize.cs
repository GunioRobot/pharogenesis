initialize
	"BrowserCodeController initialize"
	"1/8/96 sw: added senders/implementors/references.  1/15/96 added browse it.
	1/22/96 sw: show command-key equivalents
	1/24/96 sw: put many into shifted side, added find & more etc.
	1/26/96 sw: fixed up cmd key equivalent
	1/31/96 sw: BrowserCodeYellowButtonMenu/Msgs no longer used"

	NewLine _ String with: Character cr.  "used to append cr in explain messages"
	self allInstancesDo: [:i | i initializeYellowButtonMenu]