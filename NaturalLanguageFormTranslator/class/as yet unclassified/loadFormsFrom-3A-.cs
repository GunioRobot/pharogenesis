loadFormsFrom: aStream

	| rr pair inst |
	rr _ ReferenceStream on: aStream.
	pair _ rr next.
	inst _ self localeID: (LocaleID isoString: pair first).
	pair second associationsDo: [:assoc |
		inst name: assoc key form: assoc value.
	].
	^ inst.
