show4

    " B3DDemoSpheres new show4"

     | view |

  self createScene4.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene4;
     scene: scene.
  view clearColor: (Color gray: 0.5).
  view rotateX: 25.4.
  view openInSystemWindow.