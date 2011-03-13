inOutdent: characterStream delta: delta
	"Add/remove a tab at the front of every line occupied by the selection. Flushes typeahead.  Derived from work by Larry Tesler back in December 1985.  Now triggered by Cmd-L and Cmd-R.  2/29/96 sw"

	| cr realStart realStop lines startLine stopLine start stop adjustStart indentation size numLines inStream newString outStream |
	
	sensor keyboard.  "Flush typeahead"
	cr := Character cr.

	"Operate on entire lines, but remember the real selection for re-highlighting later"
	realStart := self startIndex.
	realStop := self stopIndex - 1.

	"Special case a caret on a line of its own, including weird case at end of paragraph"
	(realStart > realStop and:
				[realStart < 2 or: [(paragraph string at: realStart - 1) == cr]])
		ifTrue:
			[delta < 0
				ifTrue:
					[view flash]
				ifFalse:
					[self replaceSelectionWith: Character tab asSymbol asText.
					self selectAt: realStart + 1].
			^ true].

	lines := paragraph lines.
	startLine := paragraph lineIndexOfCharacterIndex: realStart.
	stopLine := paragraph lineIndexOfCharacterIndex: (realStart max: realStop).
	start := (lines at: startLine) first.
	stop := (lines at: stopLine) last.
	
	"Pin the start of highlighting unless the selection starts a line"
	adjustStart := realStart > start.

	"Find the indentation of the least-indented non-blank line; never outdent more"
	indentation := (startLine to: stopLine) inject: 1000 into:
		[:m :l |
		m := m min: (paragraph indentationOfLineIndex: l ifBlank: [:tabs | 1000])].			

	size :=  stop + 1 - start.
	numLines := stopLine + 1 - startLine.
	inStream := ReadStream on: paragraph string from: start to: stop.

	newString := WideString new: size + ((numLines * delta) max: 0).
	outStream := ReadWriteStream on: newString.

	"This subroutine does the actual work"
	self indent: delta fromStream: inStream toStream: outStream.

	"Adjust the range that will be highlighted later"
	adjustStart ifTrue: [realStart := (realStart + delta) max: start].
	realStop := realStop + outStream position - size.

	"Prepare for another iteration"
	indentation := indentation + delta.
	size := outStream position.
	inStream := outStream setFrom: 1 to: size.

	outStream == nil
		ifTrue: 	"tried to outdent but some line(s) were already left flush"
			[view flash]
		ifFalse:
			[self selectInvisiblyFrom: start to: stop.
			size = newString size ifFalse: [newString _ outStream contents].
			self replaceSelectionWith: newString asText].
	self selectFrom: realStart to: realStop. 	"highlight only the original range"
	^ true