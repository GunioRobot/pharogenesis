newForURL: aURLString

	| pg |
	pg _ SqueakPageCache atURL: aURLString.
	^ self new setURL: aURLString page: pg
