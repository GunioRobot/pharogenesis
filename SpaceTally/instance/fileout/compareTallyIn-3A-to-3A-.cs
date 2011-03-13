compareTallyIn: beforeFileName to: afterFileName
	"SpaceTally new compareTallyIn: 'tally' to: 'tally2'"

	| answer s beforeDict a afterDict allKeys before after diff |
	beforeDict := Dictionary new.
	s := FileDirectory default fileNamed: beforeFileName.
	[s atEnd] whileFalse: [
		a := Array readFrom: s nextLine.
		beforeDict at: a first put: a allButFirst.
	].
	s close.
	afterDict := Dictionary new.
	s := FileDirectory default fileNamed: afterFileName.
	[s atEnd] whileFalse: [
		a := Array readFrom: s nextLine.
		afterDict at: a first put: a allButFirst.
	].
	s close.
	answer := String new writeStream.
	allKeys := (Set new addAll: beforeDict keys; addAll: afterDict keys; yourself) asSortedCollection.
	allKeys do: [ :each |
		before := beforeDict at: each ifAbsent: [#(0 0 0)].
		after := afterDict at: each ifAbsent: [#(0 0 0)].
		diff := before with: after collect: [ :vBefore :vAfter | vAfter - vBefore].
		diff = #(0 0 0) ifFalse: [
			answer nextPutAll: each,'  ',diff printString; cr.
		].
	].
	StringHolder new contents: answer contents; openLabel: 'space diffs'.
	


