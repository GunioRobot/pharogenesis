loadJanForms
	"EToySystem loadJanForms"

	| aReferenceStream newFormDict |
	aReferenceStream _ ReferenceStream fileNamed: 'JanForms'.
	newFormDict _ aReferenceStream next.
	aReferenceStream close.
	newFormDict associationsDo:
		[:assoc | Imports default importImage: assoc value named: assoc key]