url: aString

	| sd |
	aString isEmpty ifTrue: [url _ nil. ^ self].

	"Expand ./ and store as an absolute url"
	sd _ ServerFile new.
	sd fullPath: aString.
	url _ sd realUrl.