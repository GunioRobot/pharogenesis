perform: selector orSendTo: otherTarget
	"Selector was just chosen from a menu by a user.  If can respond, then perform it on myself.  If not, send it to otherTarget" 

	"default is that the editor does all"
	[ ^self perform: selector] on:Error do:[
		^ otherTarget perform: selector.
	].