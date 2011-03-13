say: aString 
	"aString may contain characters and punctuation.
	You may also include the # symbol in aString;
	for each one of these, a 200msec delay will be generated."

	| events stream string token delay |

	stream := ReadStream
				on: ((aString
						copyReplaceAll: '-'
						with: ' '
						asTokens: false)
						findTokens: '?# '
						keep: '?#').
	string := ''.
	delay := 0.
	[stream atEnd]
		whileFalse: [token := stream next.
			token = '#'
				ifTrue: [ self voice playSilenceMSecs: self numberSignDelay.
					delay := delay + self numberSignDelay ]
				ifFalse: [string := string , ' ' , token.
					(token = '?' or: [stream atEnd])
						ifTrue: [
							events := CompositeEvent new.
							events addAll: (self eventsFromString: string).
							events playOn: self voice delayed: delay.
							delay := delay + (events duration * 1000).
							string := ''  ]]].
	self voice flush