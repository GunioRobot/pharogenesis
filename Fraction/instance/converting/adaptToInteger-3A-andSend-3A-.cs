adaptToInteger: rcvr andSend: selector
	"If I am involved in arithmetic with an Integer, convert it to a Fraction."
	^ rcvr asFraction perform: selector with: self