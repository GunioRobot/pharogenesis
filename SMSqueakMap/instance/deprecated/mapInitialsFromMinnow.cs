mapInitialsFromMinnow
	"Try to find the developer initials from the table at minnow."

	| page end start table startString stream coll s e sub stripped dict ini problems |
	startString _ '<td> Initials </td></tr>'.
	page _ 'http://minnow.cc.gatech.edu/squeak/8' asUrl retrieveContents content.
	start _ page findString: startString.
	start _ start + startString size.
	end _ page findString: '</table>' startingAt: start.
	table _ page copyFrom: start to: end.
	stream _ ReadStream on: table.
	coll _ OrderedCollection new.
	[stream match: '<td>'.
	s _ stream position.
	stream match: '</td>'] whileTrue: [
		e _ stream position.
		sub _ table copyFrom: s + 1 to: e - 5.
		stripped _ String streamContents: [:str | | skipNext |
			skipNext _ false.
			(sub findTokens: '<>' keep: '<>') do: [:token |
				skipNext
					ifTrue: [skipNext _ false]
					ifFalse: [
						token = '<'
							ifTrue: [skipNext _ true]
							ifFalse: [token = '>' ifFalse: [str nextPutAll: token]]]]].
		coll add: stripped withBlanksTrimmed].
	dict _ Dictionary new.
	1 to: coll size - 2 by: 2 do: [:i |
		dict at: (coll at: i) put: (coll at: i + 1)].
	problems _ OrderedCollection new.
	accounts do: [:a |
		ini _ dict at: a name ifAbsent: [nil].
		((ini isNil or: [ini = '-']) or: [(ini allSatisfy: [:c | c isLetter]) not])
			ifTrue: [problems add: a name, ' has now ', (ini ifNil: ['<NONE FOUND>'])]
			ifFalse: [a initials: ini. Transcript show: ini, ' for ', a name;cr]].
	problems asSortedCollection do: [:p | Transcript show: p; cr].

