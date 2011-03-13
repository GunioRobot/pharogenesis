compareTallyIn: beforeFileName to: afterFileName

	| answer s beforeDict a afterDict allKeys before after diff |

	beforeDict _ Dictionary new.
	s _ FileDirectory default fileNamed: beforeFileName.
	[s atEnd] whileFalse: [
		a _ Array readFrom: s nextLine.
		beforeDict at: a first put: a allButFirst.
	].
	s close.
	afterDict _ Dictionary new.
	s _ FileDirectory default fileNamed: afterFileName.
	[s atEnd] whileFalse: [
		a _ Array readFrom: s nextLine.
		afterDict at: a first put: a allButFirst.
	].
	s close.
	answer _ WriteStream on: String new.
	allKeys _ (Set new addAll: beforeDict keys; addAll: afterDict keys; yourself) asSortedCollection.
	allKeys do: [ :each |
		before _ beforeDict at: each ifAbsent: [#(0 0 0)].
		after _ afterDict at: each ifAbsent: [#(0 0 0)].
		diff _ before with: after collect: [ :vBefore :vAfter | vAfter - vBefore].
		diff = #(0 0 0) ifFalse: [
			answer nextPutAll: each,'  ',diff printString; cr.
		].
	].
	StringHolder new contents: answer contents; openLabel: 'space diffs'.
	


