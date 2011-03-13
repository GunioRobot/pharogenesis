mouseButtons
	"Answer the status of the mouse buttons: an Integer between 0 and 7."

	"If queue has a new value and the front queue value has been polled enough, move on to the next mouse button movement.  Set a minimum number of times it must be polled before it will change." 
	(redButtonPollCnt _ redButtonPollCnt - 1) <= 0 ifTrue: [
		redButtonQueue size >= 2 ifTrue: [
				redButtonQueue removeFirst.  "remove old value"
				redButtonPollCnt _ MinPollCnt.
				bitState _ (bitState bitAnd: 8r376) bitOr: redButtonQueue first]
			ifFalse: [redButtonPollCnt _ -1.	"keep it pinned"]].
	^bitState bitAnd: 7