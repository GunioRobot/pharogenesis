fileOut

        | fileName result |

        result _ StandardFileMenu newFile ifNil: [^Beeper beep].
        fileName _ result directory fullNameFor: result name.
        Cursor normal showWhile:
                [self unmagnifiedForm writeOnFileNamed: fileName]