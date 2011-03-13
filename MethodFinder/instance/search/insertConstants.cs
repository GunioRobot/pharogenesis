insertConstants
	"see if one of several known expressions will do it. C is the constant we discover here."
	"C  data1+C  data1*C  data1//C  (data1*C1 + C2) (data1 = C) (data1 ~= C) (data1 <= C) (data1 >= C) 
 (data1 mod C)"

	thisData size >= 2 ifFalse: [^ self].	"need 2 examples"
	(thisData at: 1) size = 1 ifFalse: [^ self].	"only one arg, data1"

	self const ifTrue: [^ self].
	self constEquiv ifTrue: [^ self].	" ==  ~= "
	self constLessThan ifTrue: [^ self].	" <=  and  >= "

	self allNumbers ifFalse: [^ self].
	self constMod ifTrue: [^ self].
	self constPlus ifTrue: [^ self].
	self constMult ifTrue: [^ self].
	self constDiv ifTrue: [^ self].
	self constLinear ifTrue: [^ self].
