senses

	| ww |
	ww _ '"', word, '"'.
	rwStream ifNil: [self stream].
	rwStream reset.
	rwStream match: ww.
	rwStream match: ww.
	rwStream match: ' has '.
	^ (rwStream upTo: Character lf) asNumber