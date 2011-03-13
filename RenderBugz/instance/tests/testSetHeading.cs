testSetHeading
"If the bug exist there will be an infinte recursion."
"self new testSetHeading"
"self run: #testSetHeading"

| t |
cases := {
t := TransformationMorph new openCenteredInWorld } .

 self shouldntTakeLong: [ t heading:  180 .
					 self assert: ( t heading = 0.0 ) .]  .

^true  
