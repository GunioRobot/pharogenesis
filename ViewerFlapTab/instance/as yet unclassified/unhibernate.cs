unhibernate
	| wasShowing viewer |
	"recreate my viewer"

	referent ifNotNil: [
		(referent findA: Viewer) ifNotNil: [^self].
	].
	wasShowing _ flapShowing.
	viewer _ self presenter viewMorph: scriptedPlayer costume.
	wasShowing ifFalse: [self hideFlap].
	^ viewer