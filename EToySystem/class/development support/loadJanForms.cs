loadJanForms
	"EToySystem loadJanForms"

	| aReferenceStream newFormDict |
	aReferenceStream _ ReferenceStream fileNamed: 'JanForms'.
	newFormDict _ aReferenceStream next.
	aReferenceStream close.
	newFormDict associationsDo:
		[:assoc | Smalltalk imageImports add: assoc]