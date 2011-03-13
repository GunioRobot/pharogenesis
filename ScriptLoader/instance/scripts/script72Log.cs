script72Log

	"Smacc
	preferenceBrowser
	underscore
	
	Name: Kernel-md.135
Author: md
Time: 12 July 2006, 10:25:06 pm
UUID: 61de8206-a937-4ad9-a401-c82f20946fa0
Ancestors: Kernel-sd.134

fix CompiledMethod>>#= to ignore the last two literals
(we may want to extend it to take pragmas into account
for equality later...)
	
	Name: Files-md.17
Author: md
Time: 12 July 2006, 11:10:35 pm
UUID: e4f7668b-a5ed-4a46-b9ce-a100fc0985fd
Ancestors: Files-md.16

0003723: [FIX] DosFileDirectoryTests>>testFileDirectoryNonExistence
Description
The change set included with this bug report fixes the test DosFileDirectoryTests>>testFileDirectoryNonExistence

Name: MorphicTests-md.5
Author: md
Time: 12 July 2006, 11:09:16 pm
UUID: f2394cd3-e068-4a37-acfd-0258e0937a9a
Ancestors: MorphicTests-stephaneducasse.4

0003566: TileMoprhTest>>testSoundMorph fails; fix attached
Description
in 3.9a 7029 (and 3.8 6665) TileMoprhTest>>testSoundMorph fails because it expects 'silence' to be one up from 'croak' but the menu provides 'horn'. This just fixes the test.
	
	0003571: EventManager commen
Description
In 3.9a 7029 (and earlier) EventManagerTest produces one failure because of missing class comments. This cs adds reasonable class comments for EventManager and two related classes as part of the effort to get all tests to run green.

0003729: [FIX] FontTest>>testResetAfterEmphasized

Name: Exceptions-sd.8
Author: sd
Time: 13 July 2006, 3:15:11 pm
UUID: 169d4c2b-c7f8-44bd-8621-ffcf2feb1c97
Ancestors: Exceptions-md.7

0000530: ExceptionTests>>#testTimeout works only some of the time
Description
When I run this test several times with the SUnit Test Runner it sometimes works and sometimes fails

0003648: explicit ^self in #yourself
Description
... when it's important to return self, write it. (from the best practice patterns). yourself would
be a nice example to show this in a lecture.

0003628: refactoring for hasInstVarRef
Description
hasInstVarRef was only defined on the Context, this one moved the implementation from
MethodContext to compiledMethod (and just forwards from MethodContext).

Additionally, the changeset has a small refactoring to use BlockContext>>#endPC in BlockContext>>#hasInstVarRef

0003529: BlockContextTest tests fail in 7025; fix attached
Description
In 3.9a 7025 four BlockContextTest tests failed because Jerome Peace's valueSupplyingAnswers: functionality was regressed out of PopUpMenu when icons where added to the menu. I suspect that the reason this wasn't caught is that the change was made to PopUp but the relevant s-unit tests were in BlockContextTest, so I added an test few method for the so called ST80-Menus. There was also one trivial error in a single BlockContextTest which I fixed.
Without this fix running the test requires user responses on the four failing tests and several other.

	"