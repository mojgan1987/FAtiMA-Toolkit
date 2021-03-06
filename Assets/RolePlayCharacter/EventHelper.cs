﻿using ActionLibrary;
using System;
using WellFormedNames;

namespace RolePlayCharacter
{
    public class EventHelper
    {
        public static Name ActionEnd(string subject, string actionName, string target)
        {
            return Name.BuildName(Consts.EVT_ROOT_NAME, Consts.ACTION_FINISHED_NAME,
                (Name)subject, (Name)actionName, (Name)target);
        }

        public static Name PropertyChanged(string propertyName, string value, string subject)
        {
            return Name.BuildName(
                (Name)"Event",
                (Name)"Property-Change",
                (Name)subject,
                (Name)propertyName,
                (Name)value);
        }

        public static Name AddAgent(string agent)
        {
            var n = (Name)agent;
            if (!n.IsPrimitive)
                throw new ArgumentException("The agent id needs to be a primitive", nameof(agent));

            return Name.BuildName((Name)"Event", (Name)"Agent-Added", Name.SELF_SYMBOL, n, Name.SELF_SYMBOL);
        }

        public static Name RemoveAgent(string agent)
        {
            var agentName = (Name)agent;
            if (!agentName.IsPrimitive)
                throw new ArgumentException("The agent id needs to be a primitive", nameof(agent));
            return Name.BuildName((Name)"Event", (Name)"Agent-Removed", Name.SELF_SYMBOL, agentName, Name.SELF_SYMBOL);
        }


        public static Name ToStartEventName(IAction action, Name subject)
        {
            return Name.BuildName(Consts.EVT_ROOT_NAME, Consts.ACTION_START_NAME,
                subject, action.FullName, action.Target);
        }

        public static Name ToFinishedEventName(IAction action, Name subject)
        {
            return Name.BuildName(Consts.EVT_ROOT_NAME, Consts.ACTION_FINISHED_NAME,
                subject, action.FullName, action.Target);
        }
    }
}
