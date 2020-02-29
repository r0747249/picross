using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiCross;

namespace PiCross
{
    internal class DummyData
    {
        public static InMemoryDatabase Create()
        {
            var data = new DummyData();

            return new InMemoryDatabase( data.Puzzles, data.Players );
        }

        public DummyData()
        {
            this.Puzzles = CreateDummyLibrary();
            this.Players = CreateDummyPlayerDatabase();
        }

        public InMemoryDatabase.PuzzleLibrary Puzzles { get; }

        public InMemoryDatabase.PlayerDatabase Players { get; }

        private static InMemoryDatabase.PlayerDatabase CreateDummyPlayerDatabase()
        {
            var db = InMemoryDatabase.PlayerDatabase.CreateEmpty();

            var woumpousse = db.CreateNewProfile( "Woumpousse" );
            var pimousse = db.CreateNewProfile( "Pimousse" );

            return db;
        }

        private static Puzzle Puzzle0
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "x.",
                    ".x"
                    );
            }
        }

        private static Puzzle Puzzle1
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "..x..",
                    ".x.x.",
                    "x...x",
                    ".x.x.",
                    "..x.."
                    );
            }
        }

        private static Puzzle Puzzle2
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "x...x",
                    ".x.x.",
                    "..x..",
                    ".x.x.",
                    "x...x"
                    );
            }
        }

        private static Puzzle Puzzle3
        {
            get
            {
                return Puzzle.FromRowStrings(
                    ".x..x",
                    ".....",
                    "..x..",
                    "x...x",
                    ".xxx."
                    );
            }
        }

        private static Puzzle Puzzle4
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "..x..",
                    ".xxx.",
                    "xxxxx",
                    ".xxx.",
                    "..x.."
                    );
            }
        }

        /*private static Puzzle Puzzle5
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "..........",
                    "..........",
                    "..........",
                    "..........",
                    "..........",
                    "..........",
                    "..........",
                    "..........",
                    "..........",
                    ".........."
                    );
            }
        }*/ 

        private static Puzzle Puzzle6
        {
            get
            {
                return Puzzle.FromRowStrings(
                    "..........",
                    ".xxx..xxx.",
                    "...xx...x.",
                    ".xxx....x.",
                    "..xxxx....",
                    ".....xxxx.",
                    "..xxxx....",
                    "....xxxxx.",
                    "....x...x.",
                    "....x....."
                    );
            }
        }

        private static Puzzle Puzzle7
        {
            get
            {
                return Puzzle.FromRowStrings(
                    ".xx....xx.",
                    "...xxxx...",
                    "x.xxxxxx.x",
                    ".xx.xx.xx.",
                    ".xxxxxxxx.",
                    ".x.xxxx.x.",
                    ".xxxxxxxx.",
                    ".xx.xx.xx.",
                    "x.xxxxxx.x",
                    "...xxxx..."
                    );
            }
        }

        private static Puzzle Puzzle8
        {
            get
            {
                return Puzzle.FromRowStrings(
                    ".......xx.xxxx.",
                    ".....xxx.xxxxxx",
                    "...xxxx.xxxxx.x",
                    "..xxxx.xxxxxxxx",
                    ".xxxx.xxxxx.xxx",
                    "xx...x...x.xxxx",
                    "x.........xxxx.",
                    "x.........xxxx.",
                    ".x.......xxxxx.",
                    ".x.......xxxx..",
                    ".x.......xxxx..",
                    ".x.......xxx...",
                    ".x.......xxx...",
                    ".x.......xx....",
                    ".xxxxxxxxx....."
                    );
            }
        }


        private static InMemoryDatabase.PuzzleLibrary CreateDummyLibrary()
        {
            var library = InMemoryDatabase.PuzzleLibrary.CreateEmpty();

            var author = "Woumpousse";

            library.Create(Puzzle0, author);
            library.Create(Puzzle1, author);
            library.Create(Puzzle2, author);
            library.Create(Puzzle3, author);
            library.Create(Puzzle4, author);
            library.Create(Puzzle6, author);
            library.Create(Puzzle7, author);
            library.Create(Puzzle8, author);

            return library;
        }
    }
}
