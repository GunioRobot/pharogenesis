mouseDown: evt
 	"The only real alternative mouse clicks are the yellow button or the shift key. I will treat them as the same thing, and ignore two button presses for now. I am keeping this code around, because it is the only documentation I have of MouseButtonEvent."
	| mod |
"	Transcript show: 'anyModifierKeyPressed - '; show: evt anyModifierKeyPressed printString ; cr;
			 show: 'commandKeyPressed - '; show: evt commandKeyPressed printString ;  cr;
			 show: 'controlKeyPressed - '; show:evt controlKeyPressed printString ; cr;
			 show: 'shiftPressed - '; show: evt shiftPressed printString ; cr;
			 show: 'buttons - '; show: evt buttons printString ; cr;
			 show: 'handler - '; show: evt handler printString ;  cr;
			 show: 'position - '; show: evt position printString ; cr;
			 show: 'type - '; show: evt type printString ; cr;
			 show: 'anyButtonPressed - '; show: evt anyButtonPressed printString ; cr;
			 show: 'blueButtonPressed - '; show: evt blueButtonPressed printString ; cr;
			 show: 'redButtonPressed - '; show: evt redButtonPressed printString ; cr;
			 show: 'yellowButtonPressed - '; show: evt yellowButtonPressed printString ; cr; cr; cr."
			
	
	mod _  (evt yellowButtonPressed) | (evt shiftPressed). 
	switchState ifFalse:[
		(self doButtonAction: mod) ifTrue:
			[mod ifFalse: [ self setSwitchState: true. ].].
	] ifTrue: [
			self doButtonAction: mod.].