lastEditTime
	"Describe when this page was edited last"
	| timeOfAccept tt timeOfReq |
	timeOfAccept _ (tt _ self timeOfAccept) asSeconds + date asSeconds.
	editReqDate ifNotNil: [
		timeOfReq _ editReqTime asSeconds + editReqDate asSeconds.
		(timeOfAccept < timeOfReq) ifTrue: [
			(Time now asSeconds + Date today asSeconds - (60*60)) < timeOfReq ifTrue: [
				^ '<b>Someone is editing this page!</b>  They started ', 
					(Time now subtractTime: editReqTime) intervalString, ' ago']]].
	^ 'Last edited: ', date printString, ' at ', tt printString
